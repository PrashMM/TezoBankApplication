using Models;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services
{
    public class DatabaseService : IDatabaseServices
    {
        private SqlConnection OpenConnection()
        {
            SqlConnection con = new("data source=sql-dev; database=AccountHolder; integrated security=SSPI");
            con.Open();
            return con;
        }
        

        public void CreateAccountHolderTable()
        { 
            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("CREATE TABLE [userTable](fullName VARCHAR(100), mobileNumber VARCHAR(100), addressName VARCHAR(100), pincode VARCHAR(100), aadharNumber VARCHAR(100),accountNumber VARCHAR(100) NOT NULL PRIMARY KEY NONCLUSTERED DEFAULT NEWID(), initialAmount FLOAT NOT NULL, balance FLOAT NOT NULL, CreatedOn DATE, LastModifiedOn DATE)", con);
                    
                    cmd.ExecuteNonQuery();
                    
                    //  Console.WriteLine("Table created successfully. ");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void CreateTransactionsTable()
        {

            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("CREATE TABLE [transactions] (Id INT NOT NULL PRIMARY KEY IDENTITY, Time DATETIME, Amount FLOAT NOT NULL, UserAccountId VARCHAR(100), ReceiverAccountId VARCHAR(100) NOT NULL, Type INT NOT NULL,FOREIGN KEY (UserAccountId) REFERENCES [userTable](accountNumber), FOREIGN KEY (ReceiverAccountId) REFERENCES [userTable](accountNumber) )", con);

                    cmd.ExecuteNonQuery();

                   //  Console.WriteLine("Tranactions Table created successfully.");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void AddTransactionInsideTable(Transaction transaction)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [transactions] (Time, Amount, UserAccountId, ReceiverAccountId, Type) VALUES (@Time, @Amount, @UserAccountId, @ReceiverAccountId, @Type)", con);
                    cmd.Parameters.AddWithValue("@Time", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@Amount", transaction.Amount);
                    cmd.Parameters.AddWithValue("@UserAccountId", transaction.UserAccount.AccountDetails.AccountNumber);
                    if (transaction.ReceiverAccount != null)
                    {
                        cmd.Parameters.AddWithValue("@ReceiverAccountId", transaction.ReceiverAccount.AccountDetails.AccountNumber);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ReceiverAccountId", transaction.UserAccount.AccountDetails.AccountNumber);
                    }
                    cmd.Parameters.AddWithValue("@Type", transaction.Type);

                    cmd.ExecuteNonQuery();

                    // Console.WriteLine("Holder Transactions inserted successfully inside Table.");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void AddHoldersInsideTable(AccountHolder holder)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [userTable] (fullName, mobileNumber, addressName, pincode, aadharNumber, accountNumber, initialAmount, balance, createdOn, LastModifiedOn) VALUES (@FullName, @MobileNumber, @AddressName, @Pincode, @AadharNumber, @AccountNumber, @InitialAmount, @Balance, @CreatedOn, @LastModifiedOn)", con);

                    cmd.Parameters.AddWithValue("@FullName", holder.CustomerDetails.FullName);
                    cmd.Parameters.AddWithValue("@MobileNumber", holder.CustomerDetails.MobileNumber);
                    cmd.Parameters.AddWithValue("@AddressName", holder.CustomerDetails.AddressDetails.Location);
                    cmd.Parameters.AddWithValue("@Pincode", holder.CustomerDetails.AddressDetails.Pincode);
                    cmd.Parameters.AddWithValue("@AadharNumber", holder.CustomerDetails.AadharNumber);
                    cmd.Parameters.AddWithValue("@AccountNumber", holder.AccountDetails.AccountNumber);
                    cmd.Parameters.AddWithValue("@InitialAmount", holder.AccountDetails.Balance);
                    cmd.Parameters.AddWithValue("@Balance", holder.AccountDetails.Balance);
                    cmd.Parameters.AddWithValue("@CreatedOn", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@LastModifiedOn", DateTime.UtcNow);

                    cmd.ExecuteNonQuery();

                    // Console.WriteLine("Holder Deatils inserted successfully inside Table.");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void UpdateHolderName(AccountHolder accountHolder, string newName)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [userTable] SET fullName = @NewName WHERE accountNumber = @AccountNumber", con);
                    cmd.Parameters.AddWithValue("@NewName", newName);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountHolder.AccountDetails.AccountNumber);

                    cmd.ExecuteNonQuery();

                    // Console.WriteLine("Holder Name updated successfully inside Table");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void UpdateHolderAddress(AccountHolder accountHolder, string newAddress)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("UPDATE [userTable] SET addressName = @AddressName WHERE accountNumber = @AccountNumber", con);
                    cmd.Parameters.AddWithValue("@AddressName", newAddress);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountHolder.AccountDetails.AccountNumber);
                    
                    cmd.ExecuteNonQuery();

                    // Console.WriteLine("Holder Address updated successfully inside Table");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void UpdateDepositAmount(AccountHolder accountHolder, int amount)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("UPDATE [userTable] SET balance = balance + @Amount WHERE accountNumber = @AccountNumber", con);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountHolder.AccountDetails.AccountNumber);
                    
                    cmd.ExecuteNonQuery();

                    // Console.WriteLine("Amount updated successfully inside Table");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void UpdateWithdrawAmount(AccountHolder accountHolder, int amount)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [userTable] SET balance = balance - @Amount WHERE accountNumber = @AccountNumber", con);

                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountHolder.AccountDetails.AccountNumber);
                    cmd.ExecuteNonQuery();

                    // Console.WriteLine("Amount updated successfully inside Table");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void UpdateTransferAmount(AccountHolder accountHolder, AccountHolder receiverAccount, int transferAmount)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd1 = new SqlCommand("UPDATE [userTable] SET balance = balance - @TransferAmount WHERE accountNumber = @SenderAccountNumber", con);
                    cmd1.Parameters.AddWithValue("@TransferAmount", transferAmount);
                    cmd1.Parameters.AddWithValue("@SenderAccountNumber", accountHolder.AccountDetails.AccountNumber);
                    cmd1.ExecuteNonQuery();


                    SqlCommand cmd2 = new SqlCommand("UPDATE [userTable] SET balance = balance + @TransferAmount WHERE accountNumber = @ReceiverAccountNumber", con);
                    cmd2.Parameters.AddWithValue("@TransferAmount", transferAmount);
                    cmd2.Parameters.AddWithValue("@ReceiverAccountNumber", receiverAccount.AccountDetails.AccountNumber);
                    cmd2.ExecuteNonQuery();

                    // Console.WriteLine("Transfered Amount updated successfully.");

                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }


        public void UpdateLastModificationTime(AccountHolder accountHolder)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [userTable] SET LastModifiedOn = @LastModifiedOn WHERE accountNumber = @AccountNumber", con);
                   
                    cmd.Parameters.AddWithValue("@LastModifiedOn", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountHolder.AccountDetails.AccountNumber);
                   
                    cmd.ExecuteNonQuery();

                    // Console.WriteLine("Time updated successfully.");

                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void ErrorMessage(Exception ex)
        {
            Console.WriteLine($"Error updating data: {ex.Message}");
        }
    }
}
