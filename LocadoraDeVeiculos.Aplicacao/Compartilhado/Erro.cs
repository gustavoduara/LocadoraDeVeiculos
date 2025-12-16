using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Aplicacao.Compartilhado
{
    /// <summary>
    /// Classe customizada para representar um erro na aplicação com informações de contexto (Reasons e Metadata).
    /// </summary>
    public class Error
    {
        public string Message { get; }
        public List<string> Reasons { get; private set; } = new List<string>();
        public Dictionary<string, object> Metadata { get; private set; } = new Dictionary<string, object>();

        public Error(string message)
        {
            Message = message;
        }

        // Permite encadear causas do erro (string)
        public Error CausedBy(string reason)
        {
            Reasons.Add(reason);
            return this;
        }

        // Permite encadear múltiplas causas (IEnumerable<string>)
        public Error CausedBy(IEnumerable<string> reasons)
        {
            Reasons.AddRange(reasons);
            return this;
        }

        // Permite encadear uma exceção como causa
        public Error CausedBy(Exception ex)
        {
            Reasons.Add($"Exceção: {ex.GetType().Name}. Mensagem: {ex.Message}");
            return this;
        }

        // Permite adicionar metadados (informações chave/valor) ao erro
        public Error WithMetadata(string key, object value)
        {
            Metadata[key] = value;
            return this;
        }
    }
}