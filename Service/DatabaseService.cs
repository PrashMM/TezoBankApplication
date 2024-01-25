using Models;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services
{
    public class DatabaseService : IDatabaseServices
    {
        private SqlConnection OpenConnection()
        {
            SqlConnection con = new SqlConnection("data source=sql-dev; database=AccountHolder; integrated security=SSPI");
            con.Open();
            return con;
        }

        public void CreateTable()
        {

            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("CREATE TABLE [user](fullName VARCHAR(100), mobileNumber VARCHAR(100), addressName VARCHAR(100), pincode VARCHAR(100), aadharNumber VARCHAR(100), accountNumber VARCHAR(100), initialAmount FLOAT NOT NULL, balance FLOAT NOT NULL, CreatedOn DATE, LastModifiedOn DATE)", con);

                    cmd.ExecuteNonQuery();

                    
                    Console.WriteLine("Table created successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating data: {ex.Message}");
            }
        }

        

        public void AddHoldersInsideTable(AccountHolder holder)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [user] (fullName, mobileNumber, addressName, pincode, aadharNumber, accountNumber, initialAmount, balance, createdOn, LastModifiedOn) VALUES (@FullName, @MobileNumber, @AddressName, @Pincode, @AadharNumber, @AccountNumber, @InitialAmount, @Balance, @CreatedOn, @LastModifiedOn)", con);

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

                    Console.WriteLine("Holder Deatils inserted successfully inside Table.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating data: {ex.Message}");
            }
        }

        public void UpdateHolderName(AccountHolder accountHolder, string newName)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [user] SET fullName = @NewName WHERE accountNumber = @AccountNumber", con);
                    cmd.Parameters.AddWithValue("@NewName", newName);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountHolder.AccountDetails.AccountNumber);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Holder Name updated successfully inside Table");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating data: {ex.Message}");
            }
        }

        public void UpdateHolderAddress(AccountHolder accountHolder, string newAddress)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("UPDATE [user] SET addressName = @AddressName WHERE accountNumber = @AccountNumber", con);
                    cmd.Parameters.AddWithValue("@AddressName", newAddress);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountHolder.AccountDetails.AccountNumber);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Holder Address updated successfully inside Table");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating data: {ex.Message}");
            }
        }

        public void UpdateDepositAmount(AccountHolder accountHolder, int amount)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {

                     SqlCommand cmd = new SqlCommand("UPDATE [user] SET balance = balance + @Amount WHERE accountNumber = @AccountNumber", con);

                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountHolder.AccountDetails.AccountNumber);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Amount updated successfully inside Table");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating data: {ex.Message}");
            }
        }

        public void UpdateWithdrawAmount(AccountHolder accountHolder, int amount)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [user] SET balance = balance - @Amount WHERE accountNumber = @AccountNumber", con);

                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountHolder.AccountDetails.AccountNumber);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Amount updated successfully inside Table");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating data: {ex.Message}");
            }
        }

        public void UpdateTransferAmount(AccountHolder accountHolder, AccountHolder receiverAccount, int transferAmount)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd1 = new SqlCommand("UPDATE [user] SET balance = balance - @TransferAmount WHERE accountNumber = @SenderAccountNumber", con);
                    cmd1.Parameters.AddWithValue("@TransferAmount", transferAmount);
                    cmd1.Parameters.AddWithValue("@SenderAccountNumber", accountHolder.AccountDetails.AccountNumber);
                    cmd1.ExecuteNonQuery();


                    SqlCommand cmd2 = new SqlCommand("UPDATE [user] SET balance = balance + @TransferAmount WHERE accountNumber = @ReceiverAccountNumber", con);
                    cmd2.Parameters.AddWithValue("@TransferAmount", transferAmount);
                    cmd2.Parameters.AddWithValue("@ReceiverAccountNumber", receiverAccount.AccountDetails.AccountNumber);
                    cmd2.ExecuteNonQuery();

                    Console.WriteLine("Transfered Amount updated successfully.");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating data: {ex.Message}");
            }
        }


        public void UpdateLastModificationTime(AccountHolder accountHolder)
        {
            try
            {
                using (SqlConnection con = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [user] SET LastModifiedOn = @LastModifiedOn WHERE accountNumber = @AccountNumber", con);
                    cmd.Parameters.AddWithValue("@LastModifiedOn", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountHolder.AccountDetails.AccountNumber);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Time updated successfully.");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating data: {ex.Message}");
            }
        }
    }
}
