using PEPExtensions;
using PEPlugin;
using System;

namespace FaceDiagonalAligner
{
    public class FaceDiagonalAligner : IPEPlugin
    {
        private bool disposedValue;

        public string Name => "面対角線合わせ";

        public string Version => "1.0";

        public string Description => "同一頂点から構成される面の対角線を整合させる PMX Editor プラグイン";

        public IPEPluginOption Option => new PEPluginOption();

        ControlForm form;

        public void Run(IPERunArgs args)
        {
            try
            {
                if (form == null)
                    form = new ControlForm(args);

                form.Visible = true;
                form.LoadPmx();
            }
            catch (Exception ex)
            {
                Utility.ShowException(ex);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                    form?.Dispose();
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~FaceDiagonalAligner()
        // {
        //     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
