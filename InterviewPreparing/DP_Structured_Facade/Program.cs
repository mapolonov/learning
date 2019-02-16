

//Шаблон Facade (Фасад) — Шаблон проектирования, 
//позволяющий скрыть сложность системы путем сведения всех возможных внешних вызовов к одному объекту, 
//делегирующему их соответствующим объектам системы.
//Шаблон используется если необходимо:
// упростить доступ к сложной системе;
// (или) создать различные уровни доступа к системе;
// (или) уменьшить число зависимостей между системой и клиентом.

namespace DP_Structured_Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer facade = new Computer();
            facade.startComputer();
        }
    }

    /* Complex parts */

    class CPU
    {
        public void freeze() {  }
        public void jump(long position) {  }
        public void execute() {  }
    }

    class Memory
    {
        public void load(long position, byte[] data) { }
    }

    class HardDrive
    {
        public byte[] read(long lba, int size)
        {
            return new byte[] { };
        }
    }

    /* Facade */

    class Computer
    {
        private CPU cpu;
        private Memory memory;
        private HardDrive hardDrive;

        const long BOOT_ADDRESS = 0;
        const long BOOT_SECTOR = 1;
        const int SECTOR_SIZE = 256;

        public Computer()
        {
            this.cpu = new CPU();
            this.memory = new Memory();
            this.hardDrive = new HardDrive();
        }

        public void startComputer()
        {
            cpu.freeze();
            memory.load(BOOT_ADDRESS, hardDrive.read(BOOT_SECTOR, SECTOR_SIZE));
            cpu.jump(BOOT_ADDRESS);
            cpu.execute();
        }

    }


}
