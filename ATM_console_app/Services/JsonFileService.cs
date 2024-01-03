using ATM_console_app.Models;
using Newtonsoft.Json;

namespace ATM_console_app.Services
{
    public class JsonFileService
    {
        public void UpdateJson(List<AccountHolder> accountHolderList)
        {
            string updatedJson = JsonConvert.SerializeObject(accountHolderList);
            File.WriteAllText(@"C:\json\account.json", updatedJson);
        }
    }
}
