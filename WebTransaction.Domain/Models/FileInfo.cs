namespace WebTransaction.Domain.Models
{
    public class FileInfo
    {
        public int FileId { get; set; }
        public string Title { get; set; }
        public byte[] Contents { get; set; }
    }
}