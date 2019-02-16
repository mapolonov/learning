using System;
using System.Collections.Generic;

//Хранитель (также известный как Memento, Token, Лексема) — поведенческий шаблон проектирования.
//Позволяет не нарушая инкапсуляцию зафиксировать и сохранить внутреннее состояния объекта так, 
//чтобы позднее восстановить его в этом состоянии.
//Структура
//Originator - "Создатель"
//Caretaker - "Опекун"
//Memento - "Хранитель"
namespace DP_Behavioral_Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Originator.Memento> savedStates = new List<Originator.Memento>();

            Originator originator = new Originator();
            originator.set("State1");
            originator.set("State2");
            
            savedStates.Add(originator.saveToMemento());
            
            originator.set("State3");
            // We can request multiple mementos, and choose which one to roll back to.
            savedStates.Add(originator.saveToMemento());

            originator.set("State4");

            originator.restoreFromMemento(savedStates[0]);

        }
    }

    class Originator
    {
        private String state;
        // The class could also contain additional data that is not part of the
        // state saved in the memento.

        public void set(String state)
        {
            Console.WriteLine("Originator: Setting state to " + state);
            this.state = state;
        }

        public Memento saveToMemento()
        {
            Console.WriteLine("Originator: Saving to Memento.");
            return new Memento(state);
        }

        public void restoreFromMemento(Memento memento)
        {
            state = memento.getSavedState();
            Console.WriteLine("Originator: State after restoring from Memento: " + state);
        }

        public class Memento
        {
            private String state;

            public Memento(String stateToSave)
            {
                state = stateToSave;
            }

            public String getSavedState()
            {
                return state;
            }
        }
    }

}
