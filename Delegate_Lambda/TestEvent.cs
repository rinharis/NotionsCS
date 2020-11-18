using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    class TestEvent
    {
        public TestEvent()
        {
            Demo_Subscribe_Notify_Using_Event_And_Delegate();
            Demo_Subscribe_Notify_Using_Event_EventHandler();
        }

        private void Demo_Subscribe_Notify_Using_Event_And_Delegate()
        {
            Console.WriteLine("\nDemo Subscribe and Notify using Event and Delegate");
            Voiture1 voiture = new Voiture1() { Prix = 10000 };
            //When notified (by ChangementDePrix event), do voiture_ChangementDePrix
            Voiture1.DelegateDeChangementDePrix delegateDeChangementDePrix = voiture_ChangementDePrix;
            //subscription
            voiture.ChangementDePrix += delegateDeChangementDePrix;
            //voiture.ChangementDePrix += new Voiture.DelegateDeChangementDePrix(voiture_ChangementDePrix);
            //voiture.ChangementDePrix += voiture_ChangementDePrix;

            voiture.PromoSurLePrix();
        }

        private void Demo_Subscribe_Notify_Using_Event_EventHandler()
        {
            Console.WriteLine("\nDemo Subscribe and Notify using event EventHandler<>");
            Voiture2 voiture = new Voiture2 { Prix = 10000 };
            voiture.ChangementDePrix += voiture_ChangementDePrix;
            voiture.PromoSurLePrix();
        }

        private void voiture_ChangementDePrix(decimal nouveauPrix)
        {
            Console.WriteLine("Prix changed to " + nouveauPrix);
        }

        private void voiture_ChangementDePrix(object sender, ChangementDePrixEventArgs e)
        {
            Console.WriteLine("Prix changed to  " + e.Prix);
        }
    }


    public class Voiture1
    {
        public delegate void DelegateDeChangementDePrix(decimal nouveauPrix);
        public event DelegateDeChangementDePrix ChangementDePrix;
        public decimal Prix { get; set; }

        public void PromoSurLePrix()
        {
            Prix = Prix / 2;
            //Notify event for new Prix if there is subscriber
            if (ChangementDePrix != null)
                ChangementDePrix(Prix);
        }
    }

   
    public class ChangementDePrixEventArgs : EventArgs
    {
        public decimal Prix { get; set; }
    }
    public class Voiture2
    {
        public event EventHandler<ChangementDePrixEventArgs> ChangementDePrix;
        public decimal Prix { get; set; }

        public void PromoSurLePrix()
        {
            Prix = Prix / 2;
            if (ChangementDePrix != null)
                ChangementDePrix(this, new ChangementDePrixEventArgs { Prix = Prix });
        }
    }
}
