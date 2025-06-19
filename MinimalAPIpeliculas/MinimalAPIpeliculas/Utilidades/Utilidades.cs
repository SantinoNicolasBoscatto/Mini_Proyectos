namespace MinimalAPIpeliculas.Utilidades
{
    public static class Utilidades
    {
        public static string CampoRequeridoMensaje = "El Campo {PropertyName} es requerido";

        public static bool PrimeraLetraEnMayuscula(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return true;
            var primeraLetra = valor[0].ToString();
            return primeraLetra == primeraLetra.ToUpper();
        }
    }

}
