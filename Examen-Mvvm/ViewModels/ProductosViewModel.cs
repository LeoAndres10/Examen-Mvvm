using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Examen_Mvvm.ViewModels
{
    public partial class ProductosViewModel : ObservableObject
    {

        [ObservableProperty]
        private double producto1;
        [ObservableProperty]
        private double producto2;
        [ObservableProperty]
        private double producto3;
        [ObservableProperty]
        private double subtotal;
        [ObservableProperty]
        private double descuento;
        [ObservableProperty]
        private double total;


        public ProductosViewModel()
        {

        }


        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private void Calcular()
        {
            try
            {
                double resultado;


                if (Validar())
                {
                    Subtotal = Producto1 + Producto2 + Producto3;
                    if (Subtotal >= 0 && Subtotal <= 999.99)
                    {
                        Alerta("ADVERTENCIA", "No aplica descuento");
                        Descuento = 0;
                        Total = Subtotal;
                    } else if (Subtotal >= 1000.00 && Subtotal <= 4999.99)
                    {
                        Alerta("ADVERTENCIA", "Se le aplicara un 10 % de descuento a su compra");
                        Descuento = (Producto1 + Producto2 + Producto3) * 0.10;
                        Subtotal = (Producto1 + Producto2 + Producto3) + Descuento;
                        
                        Total = Subtotal;
                    }else if(Subtotal >=5000.00 && Subtotal <= 9999.99)
                    {
                        Alerta("ADVERTENCIA", "Se le aplicara un 20 % de descuento a su compra");
                        Descuento = (Producto1 + Producto2 + Producto3) * 0.20;
                        Subtotal = (Producto1 + Producto2 + Producto3) + Descuento;

                        Total = Subtotal;
                    }else if (Subtotal >= 10000.00)
                    {
                        Alerta("ADVERTENCIA", "Se le aplicara un 30 % de descuento a su compra");
                        Descuento = (Producto1 + Producto2 + Producto3) * 0.30;
                        Subtotal = (Producto1 + Producto2 + Producto3) + Descuento;

                        Total = Subtotal;

                    } 
                }



            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }

        }
        private bool Validar()
        {
            bool esValido = true;
        
            if (Producto1 == 0 || Producto2 == 0 || Producto3 == 0 )
            {
                Alerta("ADVERTENCIA", "Uno o varios de campos estan vacios");
                esValido = false;

            }

            return esValido;
        }

        [RelayCommand]
        private void Limpiar()
        {
            Producto1 = 0;
            Producto2 = 0;
            Producto3 = 0;
            Subtotal = 0;
            Descuento = 0;
            Total = 0;
        }

    }
}
