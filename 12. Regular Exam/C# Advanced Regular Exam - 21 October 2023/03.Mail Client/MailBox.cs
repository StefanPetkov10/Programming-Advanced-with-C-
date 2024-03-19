using System.Runtime.InteropServices;
using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Archive = new List<Mail>();
            Inbox = new List<Mail>();
        }

        public int Capacity { get; set; }
        public List<Mail> Archive { get; set; }
        public List<Mail> Inbox { get; set; }

        public void IncomingMail(Mail mailbox)
        {
            if (Inbox.Count < Capacity)
            {
                Inbox.Add(mailbox);
            }
        }
        //public bool DeleteMail(string sender)
        //{
        //    Mail mail = Inbox.FirstOrDefault(s => s.Sender == sender);
        //    if (mail != null)
        //    {
        //        Inbox.Remove(mail);
        //        return true;
        //    }
        //    else return false;
        //}
        public bool DeleteMail(string sender)
    => Inbox.Remove(Inbox.FirstOrDefault(m => m.Sender == sender));
        public int ArchiveInboxMessages()
        {
            int count = Inbox.Count;
            Archive.AddRange(Inbox);
            Inbox = new List<Mail>();

            return count;
        }


        //public string GetLongestMessage() => Inbox.MaxBy(c => c.Body.Length).ToString();
        public string GetLongestMessage()
          => Inbox.OrderByDescending(m => m.Body.Length).FirstOrDefault().ToString();

        public string InboxView()
        {

            StringBuilder sb = new();
            sb.AppendLine("Inbox:");

            foreach (Mail mail in Inbox)
            {
                sb.AppendLine(mail.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
