using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace K33P3R
{
    class Core
    {
        List<string> listEmail = new List<string>();
        List<string> listUsername = new List<string>();
        List<string> listPassword = new List<string>();
        List<string> listNote = new List<string>();

        string offset = "    ";

        public void Main()
        {
            Console.Clear();

            loadAndShowField();

            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│     << Keep & Secure by xGabbro & Aspired  >>      │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ - [1]Per aggiungere un campo                       │");
            Console.WriteLine("│ - [2]Per rimuovere un campo                        │");
            Console.WriteLine("│ - [3]Per modificare un campo                       │");
            Console.WriteLine("│ - [4]Per cercare                                   │");
            Console.WriteLine("│ - [5]Impostazioni                                  │");
            Console.WriteLine("│ - [99]Per uscire                                   │");
            Console.WriteLine("└────────────────────────────────────────────────────┘" + "\n");

            Console.Write(" --> Scelta: ");
            string _choose = Console.ReadLine();

            Console.WriteLine("");
            if (_choose == "1") addField();
            else if (_choose == "2") removeField();
            else if (_choose == "3") changeField();
            else if (_choose == "4") searchField();
            else if (_choose == "5") settings();
            else if (_choose == "99") Environment.Exit(0);
            else Console.WriteLine("Errore! Scegliere un opzione!");

            Console.ReadKey();
            Main();
        }

        private void addField()
        {
            Console.Clear();

            Console.Write("Inserisci l'email [facoltativa]: ");
            string _email = Console.ReadLine();

            Console.Write("Inserisci il nome utente: ");
            string _username = Console.ReadLine();

            Console.Write("Inserisci la password: ");
            string _password = Console.ReadLine();

            Console.Write("Inserisci una nota [facoltativa]: ");
            string _note = Console.ReadLine();

            if (_email == "") _email = "XXX";
            if (_note == "") _note = "XXX";

            if (_username == "" || _password == "")
                Console.WriteLine("\n" + "ERRORE! Bisogna compilare tutti i campi obbligatori!");

            listEmail.Add(_email);
            listUsername.Add(_username);
            listPassword.Add(_password);
            listNote.Add(_note);

            pushField();
            Console.WriteLine("\n" + "Campo aggiunto correttamente!");
        }

        private void removeField()
        {

            Console.Write("Inserisci l'ID della password: ");
            int _ID = stringToInt(Console.ReadLine());

            listEmail.RemoveAt(_ID);
            listUsername.RemoveAt(_ID);
            listPassword.RemoveAt(_ID);
            listNote.RemoveAt(_ID);

            pushField();
            Console.WriteLine("\n" + "Campo eliminato correttamente!");
        }

        private void changeField()
        {

            Console.Write("Inserisci l'ID del campo da modificare: ");
            int _ID = stringToInt(Console.ReadLine());

            Console.Write("Inserisci la nuova email [" + listEmail[_ID] + "]:");
            string _newEmail = Console.ReadLine();

            Console.Write("Inserisci il nuovo username [" + listUsername[_ID] + "]:");
            string _newUsername = Console.ReadLine();

            Console.Write("Inserisci la nuova password [" + listPassword[_ID] + "]:");
            string _newPassword = Console.ReadLine();

            Console.Write("Inserisci la nuova nota [" + listNote[_ID] + "]:");
            string _newNote = Console.ReadLine();

            if (!(_newEmail == "" || _newEmail == null)) listEmail[_ID] = _newEmail;
            if (!(_newUsername == "" || _newUsername == null)) listUsername[_ID] = _newUsername;
            if (!(_newPassword == "" || _newPassword == null)) listPassword[_ID] = _newPassword;
            if (!(_newNote == "" || _newNote == null)) listNote[_ID] = _newNote;

            pushField();
            Console.WriteLine("\n" + "Campo cambiato correttamente!");
        }

        private void searchField()
        {
            List<int> _findedItems = new List<int>();
            string _offset = "  ";

            Console.WriteLine("Cercare in base: ");
            Console.WriteLine("1.All'email");
            Console.WriteLine("2.Al nome");
            Console.WriteLine("3.Alla nota");
            Console.Write("Scelta:");
            string _choose = Console.ReadLine();

            Console.Write("Inserisci la parola: ");
            string _word = Console.ReadLine();
            _word.ToLower();

            Console.Clear();
            Console.WriteLine("┌─");
            Console.WriteLine("│" + _word + ":");

            if (_choose == "1")
                for (int i = 0; i < listEmail.Count - 1; i++)
                {
                    if (listEmail[i] == _word)
                    {
                        Console.Write("└───> ");
                        Console.Write("Username: " + listUsername[i] + _offset);
                        Console.Write("Password: " + listPassword[i] + _offset);
                        Console.WriteLine("Nota: " + listNote[i]);
                    }
                }
            else if (_choose == "2")
                for (int i = 0; i < listUsername.Count - 1; i++)
                {
                    if (listUsername[i] == _word)
                    {
                        Console.Write("└───> ");
                        Console.Write("Email: " + listEmail[i] + _offset);
                        Console.Write("Password: " + listPassword[i] + _offset);
                        Console.WriteLine("Nota: " + listNote[i]);
                    }
                }
            else if (_choose == "3")
                for (int i = 0; i < listNote.Count - 1; i++)
                {
                    if (listNote[i] == _word)
                    {
                        Console.Write("└───> ");
                        Console.Write("Username: " + listEmail[i] + _offset);
                        Console.Write("Username: " + listUsername[i] + _offset);
                        Console.WriteLine("Password: " + listPassword[i] + _offset);
                    }
                }

        }

        private void settings()
        {
            Console.Clear();

            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│     << Keep & Secure by xGabbro & Aspired  >>      │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ - [1]Cambia la Password di login                   │");
            Console.WriteLine("│ - [2]Formatta tutto                                │");
            Console.WriteLine("│ - [99]Torna indietro                               │");
            Console.WriteLine("└────────────────────────────────────────────────────┘" + "\n");

            Console.WriteLine("Scelta: ");
            string _choose = Console.ReadLine();

            Console.WriteLine("");
            if (_choose == "1") changeLoginPassword();
            else if (_choose == "2") formatAll();
            else if (_choose == "3") exportPasswordTXT();
            else if (_choose == "99") return;

        }

        private void changeLoginPassword()
        {

            Console.Write("Inserisci la password attuale: ");
            string _currentPassword = Console.ReadLine();

            Console.Write("Inserisci la nuova password: ");
            string _newPassword = Console.ReadLine();

            Console.Write("Reinserisci la nuova password: ");
            string _confirmNewPassword = Console.ReadLine();

            if (_currentPassword == Properties.Settings.Default.LoginPassword)

                if (_newPassword == _confirmNewPassword)
                {

                    Properties.Settings.Default.LoginPassword = _newPassword;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                    Console.WriteLine("\n" + "Password di login cambiata correttamente!");
                }
                else Console.WriteLine("\n" + "ERRORE! Le due password non corrispondono!");

            else Console.WriteLine("\n" + "ERRORE! Password attuale errata!");

        }

        private void formatAll()
        {

            Console.WriteLine("Sei proprio sicuro di formattare tutto (perderai ogni cosa) [SI/no]:");
            string _answer = Console.ReadLine().ToLower();

            if (_answer == "no") return;

            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        private void exportPasswordTXT()
        {
            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.Filter = "Text file|*.txt";
            sfd1.Title = "Salva il file .txt";

            if (sfd1.ShowDialog() == DialogResult.OK)
            {
                TextWriter sw = new StreamWriter(sfd1.OpenFile());

                for (int i = 0; i < listPassword.Count - 1; i++)
                {
                    string _offset = "  ";

                    sw.Write(i + ")" + _offset);
                    sw.Write("Email: " + listEmail[i] + _offset);
                    sw.Write("Username: " + listUsername[i] + _offset);
                    sw.Write("Password: " + listPassword[i] + _offset);
                    sw.WriteLine("Nota: " + listNote[i]);
                }
                sw.Close();
            }

        }

        private void loadAndShowField()
        {
            Console.Clear();
            listEmail.Clear();
            listUsername.Clear();
            listPassword.Clear();
            listNote.Clear();

            if (Properties.Settings.Default.Password == "") return;

            foreach (string _email in Properties.Settings.Default.Email.Split(new[] { offset }, StringSplitOptions.None)) listEmail.Add(_email);
            foreach (string _username in Properties.Settings.Default.Username.Split(new[] { offset }, StringSplitOptions.None)) listUsername.Add(_username);
            foreach (string _password in Properties.Settings.Default.Password.Split(new[] { offset }, StringSplitOptions.None)) listPassword.Add(_password);
            foreach (string _note in Properties.Settings.Default.Note.Split(new[] { offset }, StringSplitOptions.None)) listNote.Add(_note);

            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            for (int i = 0; i < listPassword.Count - 1; i++)
            {
                string _offset = "  ";

                Console.Write(i + ")" + _offset);
                Console.Write("Email: " + listEmail[i] + _offset);
                Console.Write("Username: " + listUsername[i] + _offset);
                Console.Write("Password: " + listPassword[i] + _offset);
                Console.WriteLine("Nota: " + listNote[i]);
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("");

        }

        private void pushField()
        {
            Properties.Settings.Default.Email = "";
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Note = "";

            if (listPassword.All(p => string.IsNullOrWhiteSpace(p)))
            {
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                return;
            }

            listEmail.ForEach(delegate (string _email)
            {
                if (!string.IsNullOrWhiteSpace(_email))
                    Properties.Settings.Default.Email += _email + offset;
            });
            listUsername.ForEach(delegate (string _username)
            {
                if (!string.IsNullOrWhiteSpace(_username))
                    Properties.Settings.Default.Username += _username + offset;
            });
            listPassword.ForEach(delegate (string _password)
            {
                if (!string.IsNullOrWhiteSpace(_password))
                    Properties.Settings.Default.Password += _password + offset;
            });
            listNote.ForEach(delegate (string _note)
            {
                if (!string.IsNullOrWhiteSpace(_note))
                    Properties.Settings.Default.Note += _note + offset;
            });

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        int stringToInt(string str)
        {
            int number = 0;
            Console.WriteLine("");

            try
            {
                number = Int32.Parse(str);
            }
            catch
            {
                Console.WriteLine("ERRORE! Inserire un numero!");
                Console.ReadKey();
                Main();
            }
            return number;
        }

    }
}
