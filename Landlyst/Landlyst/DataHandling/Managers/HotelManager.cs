﻿using Landlyst.Models.TempModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.Managers
{
    public static class HotelManager
    {
        static SQL sQL = new SQL();
        static public TempUser user;
        static Rinjdael rinjdael = new Rinjdael();
        static Sha256 sha = new Sha256();

        public static bool ConfirmUser(string initials, string password)
        {
            try
            {
                // creates sqlcommand to get the salt of user logging in
                SqlCommand command = sQL.CreateCommand();
                command.CommandText = @"Select Salt From Users Where Initials=@initials";
                command.Parameters.AddWithValue("@initials", initials);

                // converts salt to string
                DataRow row = sQL.SqlSelectCommand(command)[0];
                string salt = row[0].ToString();

                // "creates" sqlcommand to get the initials of the user logging in, based on the password entered.
                command.Parameters.Clear();
                command.CommandText = @"Select Initials From Users Where Password=@password";
                command.Parameters.AddWithValue("@password", Convert.ToBase64String(sha.GetHash(Convert.FromBase64String(rinjdael.Encrypt(password, "Landlyst", Convert.FromBase64String(salt))))));
                row = sQL.SqlSelectCommand(command)[0];
                string ini = row[0].ToString();

                if (initials == ini)
                {
                    // "creates" sqlcommand to get the position of the user loggin in
                    command.Parameters.Clear();
                    command.CommandText = @"Select Position From Users Where Initials=@initials";
                    command.Parameters.AddWithValue("@initials", ini);

                    row = sQL.SqlSelectCommand(command)[0];
                    int pos = int.Parse(row[0].ToString());

                    user = new TempUser(ini, pos);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}
