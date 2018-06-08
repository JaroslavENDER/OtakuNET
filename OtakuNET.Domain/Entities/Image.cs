namespace OtakuNET.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string MimeType { get; set; }
        public byte[] Data { get; set; }
    }
}
