using Domain.Ports;

namespace Domain.Services;


public class FileStorageService
{
    private readonly IFileStorageRepository _fileStorageRepository;

    public FileStorageService(IFileStorageRepository fileStorageRepository) =>
        _fileStorageRepository = fileStorageRepository;

    public async Task<string> UploadAsync(byte[] fileData, string extencion, string contentType)
    {
        return await _fileStorageRepository.UploadAsync(fileData, extencion, contentType);
    }

    public async Task DeleteAsync(string fileUrl)
    {
        await _fileStorageRepository.DeleteAsync(fileUrl);
    }
}