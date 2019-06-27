using System;
using System.Runtime.InteropServices;

namespace CSharpConsole
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var data = TestLibraryApi.getCurrencyList();

            Console.WriteLine();
            Console.WriteLine("00{0:X}", data.ToInt32());

            var obj = Marshal.PtrToStructure(data, typeof(WfsCimNoteTypeList));
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public unsafe static class TestLibraryApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("CPlusPlusLibrary.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr getCurrencyList();
    }

    /// <summary>
    /// 
    /// </summary>

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public unsafe struct WfsCimNoteTypeList
    {
        /// <summary>
        /// 
        /// </summary>
        public ushort usNumOfNoteTypes;

        /// <summary>
        /// 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray)]
        public WfsCimNoteType[] lppNoteTypes;
    }


    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public unsafe struct WfsCimNoteType
    {
        /// <summary>
        /// 
        /// </summary>
        public ushort usNoteID;

        /// <summary>
        /// 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] cCurrencyID;

        /// <summary>
        /// 
        /// </summary>
        public uint ulValues;

        /// <summary>
        /// 
        /// </summary>
        public ushort usRelease;

        /// <summary>
        /// 
        /// </summary>
        public byte bConfigured;
    }
}
