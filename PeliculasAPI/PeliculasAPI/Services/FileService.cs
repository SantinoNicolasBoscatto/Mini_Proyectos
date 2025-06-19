namespace PeliculasAPI.Services
{
    public interface IFilesService
    {
        Task BorrarImagen(string? ruta, string carpeta);
        Task<string> GuardarImagen(string carpeta, IFormFile file);
        Task<string> Editar(string? ruta, string carpeta, IFormFile file);
    }

    public class FileService : IFilesService
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        public FileService(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GuardarImagen(string carpeta, IFormFile file)
        {
            var extensionFile = Path.GetExtension(file.FileName);
            var newFileName = $"{Guid.NewGuid()}{extensionFile}";
            string folder = Path.Combine(webHostEnvironment.WebRootPath, carpeta);
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            string ruta = Path.Combine(folder, newFileName);
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var contenido = memoryStream.ToArray();
                await File.WriteAllBytesAsync(ruta, contenido);
            }
            var url = $"{httpContextAccessor.HttpContext!.Request.Scheme}://{httpContextAccessor.HttpContext!.Request.Host}";
            var urlArchivo = Path.Combine(url, carpeta, newFileName).Replace('\\', '/');
            return urlArchivo;
        }

        public Task BorrarImagen(string? ruta, string carpeta)
        {
            if (string.IsNullOrWhiteSpace(ruta)) return Task.CompletedTask;

            var fileName = Path.GetFileName(ruta);
            var directory = Path.Combine(webHostEnvironment.WebRootPath, carpeta, fileName);
            if (File.Exists(directory)) File.Delete(directory);
            return Task.CompletedTask;
        }

        public async Task<string> Editar(string? ruta, string carpeta, IFormFile file)
        {
            await BorrarImagen(ruta, carpeta);
            return await GuardarImagen(ruta!, file);
        }
    }
}
