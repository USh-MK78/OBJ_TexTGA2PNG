using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OBJ_TexTGA2PNG
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmdStr = string.Join(" ", args);
            if(cmdStr.Length == 0)
            {
                //ヘルプ文
                Console.WriteLine("OBJMtl_TexPathTGA2PNG by USh_MK78\r\n" +
                    "\r\n" +
                    "OBJ_TexTGA2PNG.exeの使い方\r\n" +
                    "\r\n" +
                    ".mtlファイルのテクスチャパスを*.tgaから*.pngに変更します。\r\n" +
                    "OBJ_TexTGA2PNG.exe <MTL File>\r\n" +
                    "\r\n" +
                    ".mtlファイルのテクスチャパスを*.tgaから*.pngに変更、ディレクトリのパスタイプを変更します。\r\n" +
                    "OBJ_TexTGA2PNG.exe <MTL File> -fix\r\n" +
                    "\r\n" +
                    ".mtlファイルのテクスチャパスを*.tgaから*.pngに変更、テクスチャが存在するディレクトリを変更します。\r\n" +
                    "OBJ_TexTGA2PNG.exe <MTL File> -InputDir <InDIR> -NewDir <NDIR>\r\n" +
                    "例\r\n" +
                    "A/B/C.tgaをA/C.tgaにしたい場合\r\n" +
                    "InputDir=A/B/\r\n" +
                    "NewDir=A/\r\n" +
                    "\r\n");
            }

            try
            {
                if (cmdStr == args[0])
                {

                    //OBJ_TexTGA2PNG.exe <MTL File>
                    StreamReader sr1 = new StreamReader(args[0]);
                    string sr1str = sr1.ReadToEnd();
                    sr1.Close();

                    string changeformat = sr1str.Replace(".tga", ".png");
                    System.IO.StreamWriter sw1 = new System.IO.StreamWriter(args[0] + "_fixTexType.mtl", false);
                    sw1.Write(changeformat);
                    sw1.Close();

                }
                if (cmdStr == args[0] + " -InputDir " + args[2] + " -NewDir " + args[4])
                {
                    //OBJ_TexTGA2PNG.exe <MTL File> -InputDir <InDIR> -NewDir <NDIR>
                    StreamReader sr1 = new StreamReader(args[0]);
                    string sr1str = sr1.ReadToEnd();
                    sr1.Close();

                    string changeformat = sr1str.Replace(".tga", ".png");
                    string changePath = changeformat.Replace(args[2], args[4]);
                    System.IO.StreamWriter sw1 = new System.IO.StreamWriter(args[0] + "_fixTexType_and_Path.mtl", false);
                    sw1.Write(changePath);
                    sw1.Close();
                }
                if (cmdStr == args[0] + " -fix")
                {
                    //OBJ_TexTGA2PNG.exe <MTL File> -fix
                    StreamReader sr2 = new StreamReader(args[0]);
                    string sr2str = sr2.ReadToEnd();
                    sr2.Close();

                    string changeformat2 = sr2str.Replace(".tga", ".png");
                    string pathfix = changeformat2.Replace("\\", "/");
                    System.IO.StreamWriter sw2 = new System.IO.StreamWriter(args[0] + "_fixTexType_Dir_and_Path.mtl", false);
                    sw2.Write(pathfix);
                    sw2.Close();
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                //引数が指定されていない場合このエラーが発生するため処理を終了させる
                Console.WriteLine("引数が指定されなかったため処理を強制的に終了しました。\r\n引数を指定してこのプログラムを起動してください。");
                Environment.Exit(0);

            }
        }
    }
}
