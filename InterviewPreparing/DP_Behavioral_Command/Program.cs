using System;

namespace DP_Behavioral_Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Light lamp = new Light();

            ICommand switchUp = new FlipUpCommand(lamp);
            ICommand switchDown = new FlipDownCommand(lamp);
 
            // See criticism of this model above:
            // The switch itself should not be aware of lamp details (switchUp, switchDown) 
            // either directly or indirectly
            Switch s = new Switch(switchUp, switchDown);

            s.flipUp();
            s.flipDown();
        }
    }

    /* The Command interface */
    public interface ICommand
    {
        void execute();
    }

    /* The Invoker class */
    public class Switch
    {
        private ICommand flipUpCommand;
        private ICommand flipDownCommand;

        public Switch(ICommand flipUpCmd, ICommand flipDownCmd)
        {
            this.flipUpCommand = flipUpCmd;
            this.flipDownCommand = flipDownCmd;
        }

        public void flipUp()
        {
            flipUpCommand.execute();
        }

        public void flipDown()
        {
            flipDownCommand.execute();
        }
    }

    /* The Receiver class */
    public class Light
    {
        public Light() { }

        public void turnOn()
        {
            Console.WriteLine("The light is on");
        }

        public void turnOff()
        {
            Console.WriteLine("The light is off");
        }
    }

    /* The Command for turning the light on in North America, or turning the light off in most other places */
    public class FlipUpCommand : ICommand
    {

        private Light theLight;

        public FlipUpCommand(Light light)
        {
            this.theLight = light;
        }

        public void execute()
        {
            theLight.turnOn();
        }
    }

    /* The Command for turning the light off in North America, or turning the light on in most other places */
    public class FlipDownCommand : ICommand
    {

        private Light theLight;

        public FlipDownCommand(Light light)
        {
            this.theLight = light;
        }

        public void execute()
        {
            theLight.turnOff();
        }
    }
}
