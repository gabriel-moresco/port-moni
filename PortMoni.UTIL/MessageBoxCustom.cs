using System;

namespace PortMoni.UTIL
{
    public class MessageBoxCustom
    {
        public enum ButtonOptions
        {
            Ok,
            OkCancel,
            YesNo,
            OkAuxiliary,
            OkCancelAuxiliary,
            YesNoAuxiliary
        }

        public enum Images
        {
            None,
            Checked,
            Error,
            Info
        }

        public enum ButtonResult
        {
            Positive,
            Negative,
            Auxiliary
        }

        /// <summary>
        /// MessageBox padrão WAU - Sem imagem, e somente com o botão Ok disponível
        /// </summary>
        /// <param name="title">Título do MessageBox</param>
        /// <param name="message">Mensagem a ser escrita no MessageBox</param>
        public static ButtonResult Show(string title, string message)
        {
            Views.MessageBox messageBox = new Views.MessageBox(title, message, Images.None, ButtonOptions.Ok, "", null);
            messageBox.ShowDialog();

            return messageBox.Result;
        }

        /// <summary>
        /// MessageBox padrão WAU - Imagem por escolha do usuário, e somente com o botão Ok disponível
        /// </summary>
        /// <param name="title">Título do MessageBox</param>
        /// <param name="message">Mensagem a ser escrita no MessageBox</param>
        /// <param name="images">Imagem a ser exibida no MessageBox</param>
        public static ButtonResult Show(string title, string message, Images images)
        {
            Views.MessageBox messageBox = new Views.MessageBox(title, message, images, ButtonOptions.Ok, "", null);
            messageBox.ShowDialog();

            return messageBox.Result;
        }

        /// <summary>
        /// MessageBox padrão WAU - Sem imagem, e configuração de botões por escolha do usuário
        /// </summary>
        /// <param name="title">Título do MessageBox</param>
        /// <param name="message">Mensagem a ser escrita no MessageBox</param>
        /// <param name="buttonOptions">Configuração de botões a ser exibidos no MessageBox</param>
        /// <param name="auxiliaryButtonContent">Texto exibido no botão auxiliar, se escolhido</param>
        /// <returns>Retorna ButtonResult.Positive se o usuário clicar no Botão "OK" ou "Sim"; ButtonResult.Negative se clicar em "Cancel" ou "Não" e ButtonResult.Auxiliary se clicar no botão auxiliar</returns>
        public static ButtonResult Show(string title, string message, ButtonOptions buttonOptions, string auxiliaryButtonContent = "")
        {
            Views.MessageBox messageBox = new Views.MessageBox(title, message, Images.None, buttonOptions, auxiliaryButtonContent, null);
            messageBox.ShowDialog();

            return messageBox.Result;
        }

        /// <summary>
        /// MessageBox padrão WAU - Imagem e configuração de botões por escolha do usuário
        /// </summary>
        /// <param name="title">Título do MessageBox</param>
        /// <param name="message">Mensagem a ser escrita no MessageBox</param>
        /// <param name="images">Imagem a ser exibida no MessageBox</param>
        /// <param name="buttonOptions">Configuração de botões a ser exibidos no MessageBox</param>
        /// <param name="auxiliaryButtonContent">Texto exibido no botão auxiliar, se escolhido</param>
        /// <returns>Retorna ButtonResult.Positive se o usuário clicar no Botão "OK" ou "Sim"; ButtonResult.Negative se clicar em "Cancel" ou "Não" e ButtonResult.Auxiliary se clicar no botão auxiliar</returns>
        public static ButtonResult Show(string title, string message, Images images, ButtonOptions buttonOptions, string auxiliaryButtonContent = "")
        {
            Views.MessageBox messageBox = new Views.MessageBox(title, message, images, buttonOptions, auxiliaryButtonContent, null);
            messageBox.ShowDialog();

            return messageBox.Result;
        }

        /// <summary>
        /// MessageBox de Exception WAU - Aparece a Exception.Message na tela principal, e uma tela com mais detalhes informando o Exception.StackTrace
        /// </summary>
        /// <param name="title">Título do MessageBox</param>
        /// <param name="exception">Exception que ocorreu</param>
        public static ButtonResult Show(string title, string preExceptionMessage, Exception exception)
        {
            Views.MessageBox messageBox = new Views.MessageBox(title, string.Format("{0}\n{1}", preExceptionMessage, exception.Message), Images.Error, ButtonOptions.Ok, "", exception);
            messageBox.ShowDialog();

            return messageBox.Result;
        }
    }
}
