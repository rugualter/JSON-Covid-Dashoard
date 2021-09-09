using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using JSONCovidDash.Exceptions;


namespace JSONCovidDash.Wrapper
{
    public class JSONNetWrapper
    {

        /// <summary>
        /// Converter o json em formato de string para uma estrutura conhecida e facil de pesquisar
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Dictionary<string, Dictionary<string, string>> ConvertDadosEstatisticos(string json)
        {
            Dictionary<string, Dictionary<string, string>> items = null;
            try
            {
                if (string.IsNullOrEmpty(json))
                    throw new ArgumentNullException("json");

                //Converter os dados para uma estrutura temporária
                items = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
            }
            catch (Exception ex)
            {
                items = null;
                throw new ErroConversaoJSONException(ex.Message);
            }

            return items;
        }

        /// <summary>
        /// Converter o json em formato de string para uma estrutura conhecida e facil de pesquisar
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ConvertDadosEstatisticos<T>(string json)
        {
            T items = default(T);
            try
            {
                if (string.IsNullOrEmpty(json))
                    throw new ArgumentNullException("json");

                //Converter os dados para uma estrutura temporária
                items = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                items = default(T);
                throw new ErroConversaoJSONException(ex.Message);
            }

            return items;
        }

        /// <summary>
        /// Converter a resposta do pedido json para o formato de lista
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<string> ConverterListaConcelhos(string json)
        {
            List<string> concelhos = null;
            try
            {
                if (string.IsNullOrEmpty(json))
                    throw new ArgumentNullException("json");

                concelhos = JsonConvert.DeserializeObject<List<string>>(json);

            }
            catch (Exception ex)
            {
                concelhos = null;
                throw new ErroConversaoJSONException(ex.Message);
            }

            return concelhos;
        }

    }
}
