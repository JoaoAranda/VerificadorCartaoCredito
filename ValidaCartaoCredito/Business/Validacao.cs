using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ValidaCartaoCredito.Models;

namespace ValidaCartaoCredito.Business
{
    public class Validacao
    {
        
        public string ValidaGenerico(string numeroCartao)
        {
            ETipoCartao tipoCartao;

            if ((numeroCartao.Substring(0, 2).Equals("34") || numeroCartao.Substring(0, 2).Equals("37")))
                tipoCartao = ETipoCartao.Amex;
            else if (numeroCartao.Substring(0, 4).Equals("6011"))
                tipoCartao = ETipoCartao.Discover;
            else if ((Convert.ToInt16(numeroCartao.Substring(0, 2)) >= 51) && (Convert.ToInt16(numeroCartao.Substring(0, 2)) <= 55))
                tipoCartao = ETipoCartao.MasterCard;
            else if (numeroCartao.Substring(0, 1).Equals("4"))
                tipoCartao = ETipoCartao.Visa;
            else
                tipoCartao = ETipoCartao.Desconhecido;

            bool valido = ValidaEstrutura(numeroCartao, tipoCartao);

            return String.Concat(tipoCartao.ToString() + ": ", numeroCartao, " " + (valido ? "(Válido)" : "(Inválido)") + "");
        }

        private bool ValidaEstrutura(string numeroCartao, ETipoCartao tipoCartao)
        {
            switch (tipoCartao)
            {
                case ETipoCartao.Amex:
                    if (!numeroCartao.Length.Equals(15))
                        return false;
                    break;
                case ETipoCartao.Discover:
                    if (!numeroCartao.Length.Equals(16))
                        return false;
                    break;
                case ETipoCartao.MasterCard:
                    if (!numeroCartao.Length.Equals(16))
                        return false;
                    break;
                case ETipoCartao.Visa:
                    if (!numeroCartao.Length.Equals(13) && !numeroCartao.Length.Equals(16))
                        return false;
                    break;
                default:
                    break;
            }

            int somaDosNumeros = 0;
            IEnumerable<Char> valorInvertido = numeroCartao.ToCharArray().Reverse();

            for (int i = 0; i < numeroCartao.Length; i++)
            {
                if (i % 2 == 0)
                {
                    somaDosNumeros += Convert.ToInt16(valorInvertido.ToArray()[i].ToString());
                }
                else
                {
                    int valorUni = (int)(Convert.ToInt16((valorInvertido.ToArray()[i].ToString())) * 2);
                    somaDosNumeros += Convert.ToInt16((valorUni > 9 ? (valorUni - 9) : valorUni).ToString());
                }
            }

            if ((somaDosNumeros % 10) == 0)
                return true;
            else
                return false;
        }
    }
}
