﻿using ProxySetter.Resources.Langs;
using System.Drawing;

namespace ProxySetter
{
    public class ProxySetter : VgcApis.Models.BaseClasses.Plugin
    {
        Services.PsLuncher luncher;
        public ProxySetter() { }

        #region private methods


        #endregion

        #region properties
        public override string Name => Properties.Resources.Name;
        public override string Version => Properties.Resources.Version;
        public override string Description => I18N.Description;

        public override Image Icon => Properties.Resources.VBDynamicWeb_16x;
        #endregion

        #region protected overrides
        protected override void Start(
            VgcApis.Models.IServices.IApiService api)
        {
            luncher = new Services.PsLuncher();
            luncher.Run(api);
        }

        protected override void Popup()
        {
            luncher?.Show();
        }

        protected override void Stop()
        {
            luncher?.Cleanup();
        }
        #endregion
    }
}