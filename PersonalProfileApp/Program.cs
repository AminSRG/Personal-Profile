using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddFluentValidation(current =>
                {
                    current.RegisterValidatorsFromAssemblyContaining
                        <PersonalProfilePersistence.Skills.ViewModels.SkillViewModelsValidator>();
                    current.RegisterValidatorsFromAssemblyContaining
                        <PersonalProfileApplication.Skill.Commands.SkillCommandValidation>();
                    current.LocalizationEnabled = true; // Default: [true]
                    current.AutomaticValidationEnabled = true; // Default: [true]
                    current.ImplicitlyValidateChildProperties = false; // Default: [false]
                    current.ImplicitlyValidateRootCollectionElements = false; // Default: [false]
                    current.RunDefaultMvcValidationAfterFluentValidationExecutes = false; // Default: [true]
                }); ;
PersonalProfileCore.DependencyContainer.Configureservices
    (configuration: builder.Configuration, services: builder.Services);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "Admin",
        pattern: "{controller=Skill}/{action=Index}/{id?}");
});

app.Run();
