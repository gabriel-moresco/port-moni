using PortMoni.MODEL;
using System;
using System.Linq;

namespace PortMoni.SERVICES
{
    public class DataBaseWalletServices
    {
        public static int GetLastWalletId()
        {
            int lastId = 0;

            try
            {
                lastId = DataBaseCommonServices.LoadAllRecords<Wallet>("wallets").OrderByDescending(o => o.Id).FirstOrDefault().Id;
            }
            catch (Exception) { }

            return lastId;
        }

        public static void CreateNewWallet(int walletId, string walletOwner)
        {
            DataBaseCommonServices.InsertRecord("wallets", new Wallet(walletId, walletOwner));
        }

        public static Wallet GetWalletByUserName(string userName)
        {
            return DataBaseCommonServices.GetRecordByFilter<Wallet>("wallets", "WalletOwner", userName);
        }

        public static void UpdateWallet(Wallet userWallet)
        {
            DataBaseCommonServices.UpdateRecord("wallets", userWallet.Id, userWallet);
        }
    }
}
