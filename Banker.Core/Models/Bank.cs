namespace Banker.Core.Models
{
    public class Bank
    {
        public const int MAX_NAME_LENGTH = 256;

        public Guid Id { get; }
        public string Name { get; } = string.Empty;

        private Bank(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Bank Create(Guid id, string name)
        {
            Bank bank = new Bank(id, name);
            return bank;
        }
    }
}
