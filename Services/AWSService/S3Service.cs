using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using MySqlX.XDevAPI;
using SOSPets.Domain.Models;
using SOSPets.Services.Interface;
using System.Text.RegularExpressions;

namespace SOSPets.Services.AWSService
{
    public class S3Service : IS3Service
    {
        private readonly AmazonS3Client _amazonS3Config;
        private readonly string _bucketService = "petsos";
        private readonly string _keyAccess = "AKIA3FLDZHDSWC6RCDBH";
        private readonly string _secretKey = "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";
        public S3Service(RegionEndpoint regionService)
        {
            var config = new AmazonS3Config
            {
                RegionEndpoint = regionService
            };
            var credentials = new Amazon.Runtime.BasicAWSCredentials(_keyAccess, _secretKey);
            _amazonS3Config = new AmazonS3Client(credentials, config);
            
        }
        private async Task UploadFileAsync(string bucketName, byte[] image64, string fileName)
        {
            using var memoryStream = new MemoryStream(image64);

            var fileTransferUtility = new TransferUtility(_amazonS3Config);

           await fileTransferUtility.UploadAsync(memoryStream, bucketName, fileName);

            //catch (AmazonS3Exception ex)
            //{
            //    Console.WriteLine($"Erro ao fazer upload do arquivo: {ex.Message}");
            //}
        }
        public async Task<string> SaveImageAsync(string base64Image, string folder)
        {
            var fileName = $"{Guid.NewGuid()}.jpg";

            base64Image = new Regex(@"^data:image [a-z]+;base64").Replace(base64Image, "");

            await UploadFileAsync(_bucketService, Convert.FromBase64String(base64Image), $"{folder}/" + fileName);

            return $"https://{_bucketService}.s3.amazonaws.com/{folder}/{fileName}";


        }
    }
}
