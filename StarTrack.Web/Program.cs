using StarTrack.Web.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using StarTrack.Core.Models;
using StarTrack.Core.Services;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

var _userDataProvider = new UserDataProvider(); 


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });
builder.Services.AddRazorPages();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
string HashingPassword(string pass)
{
    var salt = Encoding.Unicode.GetBytes(pass);
    var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
    password: pass,
    salt: salt,
    prf: KeyDerivationPrf.HMACSHA256,
    iterationCount: 100000,
    numBytesRequested: 256 / 8));

    return hashed;
}
app.MapPost("api/registration", (User userdata) =>
{
    _userDataProvider.CreateUser(userdata.Login, HashingPassword(userdata.Password));

    return Results.Ok();
});
// Add services to the container.



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapPost("api/login", (User userdata) =>
{
    var userId = _userDataProvider.GetUserId(userdata.Login, HashingPassword(userdata.Password));
    if (userId == null)
    {
        return Results.Unauthorized();
    }

    var claims = new List<Claim> {
        new Claim(ClaimTypes.Name, userdata.Login),
        new Claim(ClaimTypes.NameIdentifier, userId.ToString())
    };

    var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(50)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

    var response = new
    {
        access_token = encodedJwt,
        username = userdata.Login
    };

    return Results.Json(response);
});
app.MapPost("api/registration/{login}/{password}/", (string login, string password) =>
{
    _userDataProvider.CreateUser(login, HashingPassword(password));

    return Results.Ok(login);
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
