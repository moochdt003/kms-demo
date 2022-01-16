using System;
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;
using Amazon.Runtime;

namespace kms_demo
{
	public class KeyManagementService
	{
		private const string Key = "";
		private const string SecretKey = "";
		private const string KeyArn = "";
		private AmazonKeyManagementServiceClient _kmsClient;

		public KeyManagementService()
		{
			var awsBasicCridentials = new BasicAWSCredentials(Key, SecretKey);
			_kmsClient = new AmazonKeyManagementServiceClient(awsBasicCridentials, Amazon.RegionEndpoint.EUCentral1);
		}

		public async Task<byte[]> Encrypt(string filePath)
		{
			var plainText = FileHelper.FileToMemoryStream(filePath);
			EncryptRequest encryptRequest = new()
			{
				KeyId = KeyArn,
				Plaintext = plainText
			};
			MemoryStream ciphertext = (await _kmsClient.EncryptAsync(encryptRequest)).CiphertextBlob;
			return ciphertext.ToArray();
		}

		public async Task<byte[]> Decrypt(string filePath)
		{
			var ciphertextBlob = FileHelper.FileToMemoryStream(filePath);

			DecryptRequest decryptRequest = new()
			{
				CiphertextBlob = ciphertextBlob,
				KeyId = KeyArn
			};

			MemoryStream plainText = (await _kmsClient.DecryptAsync(decryptRequest)).Plaintext;
			return plainText.ToArray();
		}
	}
}

