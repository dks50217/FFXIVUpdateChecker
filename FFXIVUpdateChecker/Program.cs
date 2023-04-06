using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.StaticFiles;
using Drk.AspNetCore.MinimalApiKit;
using System.Runtime.InteropServices;
using FFXIVUCBLL.Model;
using FFXIVUCBLL.Helper;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(options => {
    options.SerializerOptions.PropertyNamingPolicy = null;
});

var app = builder.Build();

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".vue"] = "application/javascript";

app.UseFileServer(new FileServerOptions {
    RequestPath = "",
    FileProvider = new Microsoft.Extensions.FileProviders
                    .ManifestEmbeddedFileProvider(typeof(Program).Assembly, "ui"),
    StaticFileOptions = {
        ContentTypeProvider = provider
    }
});


app.MapPost("/Check", async (CheckViewModel vm) =>
{
    return FileHelper.CompareFiles(vm.old_path, vm.new_path);
});

app.RunAsDesktopTool();
