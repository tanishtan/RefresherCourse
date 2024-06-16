using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefresherCourse
{
    public interface IClock//Not right
    {
        void setAlaram();
        void readTemperatures();
        void tuneRadio();
    }
    public class AnalogClock : IClock
    {
        public void readTemperatures()
        {
            Console.WriteLine("24.5") ;
        }

        public void setAlaram()
        {
            Console.WriteLine("Time"); ;
        }

        public void tuneRadio()
        {
            throw new NotImplementedException();
        }
    }
    public class DigitalClock : IClock
    {
        public void readTemperatures()
        {
            throw new NotImplementedException();
        }

        public void setAlaram()
        {
            throw new NotImplementedException();
        }

        public void tuneRadio()
        {
            throw new NotImplementedException();
        }

        //These type of dumy behaviours should not exists.
    }

    //Create Specific interfaces
    interface IThermometr
    {
        void ReadTemp();
    }
    interface IRadio
    {
        void Tuneadio();
    }
    interface IAlaram
    {
        void setAlaram();
    }

    public class AncientClock : IAlaram, IThermometr
    {
        public void ReadTemp()
        {
            throw new NotImplementedException();
        }

        public void setAlaram()
        {
            throw new NotImplementedException();
        }
    }
    internal class ISP
    {
    }
}
