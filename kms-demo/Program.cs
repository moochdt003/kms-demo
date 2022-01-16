using kms_demo;

try
{

	string encryptedFileName = "encrypted-file.txt";

	var kms = new KeyManagementService();

	var encryptResult = await kms.Encrypt("test-file.txt");
	FileHelper.WriteToFile(encryptedFileName, encryptResult);

	var decryptResult = await kms.Decrypt(encryptedFileName);
	FileHelper.WriteToFile("decrypted-file.txt", decryptResult);
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}
