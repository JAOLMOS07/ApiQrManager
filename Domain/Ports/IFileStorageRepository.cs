namespace Domain.Ports;

public interface IFileStorageRepository
{
    Task<string> UploadAsync(byte[] fileData, string extencion, string contentType);
    Task DeleteAsync(string fileUrl);
}