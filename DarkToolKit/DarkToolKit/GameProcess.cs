using System;
using System.Diagnostics;
using System.Management.Instrumentation;
using Ernegien.HaloOnline.Utilities.Imports;
using Ernegien.HaloOnline.Utilities.Imports.Structs;
using Ernegien.HaloOnline.Utilities.Imports.Types;
using Ernegien.HaloOnline.Utilities.IO;

namespace Ernegien.HaloOnline.Utilities
{
    public class GameProcess : IDisposable
    {
        #region Fields
        private UIntPtr _allocationTableBasePtr = new UIntPtr(0x40100B);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string _name;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Process _process;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IntPtr _processHandle;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private uint _mainThreadId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IntPtr _mainThreadHandle;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private uint _tlsAddress;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ProcessMemoryStream _memoryStream;

        #endregion

        #region Properties

        /// <summary>
        /// The process name.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// The main thread id of the process.
        /// </summary>
        public uint MainThreadId
        {
            get { return _mainThreadId; }
        }

        /// <summary>
        /// The main thread handle of the process.
        /// </summary>
        public IntPtr MainThreadHandle
        {
            get { return _mainThreadHandle; }
        }

        /// <summary>
        /// The process.
        /// </summary>
        public Process Process
        {
            get { return _process; }
        }

        /// <summary>
        /// The process handle.
        /// </summary>
        public IntPtr ProcessHandle
        {
            get { return _processHandle; }
        }


        /// <summary>
        /// The TLS address.
        /// </summary>
        public uint TlsAddress
        {
            get { return _tlsAddress; }
        }

        /// <summary>
        /// Process memory stream.
        /// </summary>
        public ProcessMemoryStream Memory
        {
            get { return _memoryStream; }
        }

        #endregion

        #region Initialization & Disposal

        /// <summary>
        /// Provides access to the game process.
        /// </summary>
        /// <param name="name">The process name.</param>
        public GameProcess(string name)
        {
            _name = name;
            Initialize();
        }

        /// <summary>
        /// Initializes core components.
        /// </summary>
        private void Initialize()
        {
            _process = GetProcessByName(_name);
            _processHandle = Kernel32.OpenProcess(ProcessAccessFlags.All, false, (uint)_process.Id);
            _memoryStream = new ProcessMemoryStream(_processHandle);
            _mainThreadId = User32.GetWindowThreadProcessId(Process.MainWindowHandle);
            _mainThreadHandle = Kernel32.OpenThread(ThreadAccessFlags.All, false, MainThreadId);
            _tlsAddress = GetTlsAddress(MainThreadHandle);
            //_memoryManager = new ProcessMemoryManager(_memoryStream, _allocationTableBasePtr);
        }

        /// <summary>
        /// Disposes of and then clears the cached values and re-initializes the core components.
        /// </summary>
        public void Reset()
        {
            Dispose();
            Initialize();
        }

        /// <summary>
        /// Disposes of unmanaged resources. 
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (Memory != null)
                {
                    Memory.Dispose();
                }

                if (MainThreadHandle != IntPtr.Zero)
                {
                    Kernel32.CloseHandle(MainThreadHandle);
                }

                if (ProcessHandle != IntPtr.Zero)
                {
                    Kernel32.CloseHandle(ProcessHandle);
                }
            }
            catch
            {
                // do nothing
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Suspends the main process thread.
        /// </summary>
        public void SuspendMainThread()
        {
            Kernel32.SuspendThread(MainThreadHandle);
        }

        /// <summary>
        /// Resumes the main process thread.
        /// </summary>
        public void ResumeMainThread()
        {
            Kernel32.ResumeThread(MainThreadHandle);
        }

        /// <summary>
        /// Gets the TLS address of the specified thread and slot index.
        /// </summary>
        /// <param name="threadHandle"></param>
        /// <param name="slotIndex"></param>
        /// <returns></returns>
        public uint GetTlsAddress(IntPtr threadHandle, int slotIndex = 0)
        {
            Kernel32.SuspendThread(threadHandle);
            ThreadContext context = Kernel32.GetThreadContext(threadHandle);
            Kernel32.ResumeThread(threadHandle);
            LdtEntry ldt = Kernel32.GetThreadSelectorEntry(threadHandle, context.SegFs);

            uint tlsArrayPtr = ldt.BaseAddress + 0x2C;
            uint tlsArrayAddress = Memory.ReadUInt32(tlsArrayPtr);
            return Memory.ReadUInt32(tlsArrayAddress + slotIndex * sizeof(uint));
        }

        /// <summary>
        /// Searches for a process by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Process GetProcessByName(string name)
        {
            Process[] processes = Process.GetProcessesByName(_name);
            switch (processes.Length)
            {
                case 0: throw new InstanceNotFoundException(string.Format("The {0} process was not found.", _name));
                case 1: return processes[0];
                default: throw new Exception(string.Format("Multiple {0} processes found.", _name));
            }
        }

        #endregion
    }
}
