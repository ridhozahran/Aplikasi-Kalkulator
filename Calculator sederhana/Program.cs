
class Calculator
{
    public static double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // Nilai default adalah "bukan angka" jika suatu operasi, seperti pembagian, dapat menyebabkan kesalahan.

        // Use a switch statement to do the math.
        switch (op)
        {
            case "A":
                result = num1 + num2;
                break;
            case "B":
                result = num1 - num2;
                break;
            case "C":
                result = num1 * num2;
                break;
            case "D":
                // Minta pengguna untuk memasukkan pembagi bukan nol.
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                break;
            // Kembalikan teks untuk opsi yang salah.
            default:
                break;
        }
        return result;
    }
}
class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        // Menampilkan judul sebagai aplikasi kalkulator konsol C#.
        Console.WriteLine("Console Calculator di C#\r");
        Console.WriteLine("------------------------\n");

        while (!endApp)
        {
            // Deklarasikan variabel dan setel ke kosong.
            string numInput1 = "";
            string numInput2 = "";
            double result = 0;

            // Minta pengguna untuk mengetikkan angka pertama.
            Console.Write("Masukan angka yang akan di hitung, lalu tekan Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("Ini bukan masukan yang valid. Masukkan nilai bilangan bulat: ");
                numInput1 = Console.ReadLine();
            }

            // Minta pengguna untuk mengetikkan angka kedua.
            Console.Write("Masukan angka selanjutnya, lalu tekan Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("Ini bukan masukan yang valid. Masukkan nilai bilangan bulat: ");
                numInput2 = Console.ReadLine();
            }

            // Minta pengguna untuk memilih operator.
            Console.WriteLine("Pilih opsi dari daftar berikut:");
            Console.WriteLine("\tA - Tambah");
            Console.WriteLine("\tB - Kurang");
            Console.WriteLine("\tC - Kali");
            Console.WriteLine("\tD - Bagi");
            Console.Write("Pilihan Anda? ");

            string op = Console.ReadLine();

            try
            {
                result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("Operasi ini akan menghasilkan kesalahan matematis.\n");
                }
                else Console.WriteLine("Hasil : {0:0.##}\n", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh tidak! Pengecualian terjadi saat mencoba menghitung.\n - Detail: " + e.Message);
            }

            Console.WriteLine("------------------------\n");

            // Tunggu hingga pengguna merespons sebelum menutup.
            Console.Write("Tekan 'n' dan Enter untuk menutup aplikasi, atau tekan tombol lain dan Enter untuk melanjutkan: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); // memberi jarak antar baris
        }
        return;
    }
}