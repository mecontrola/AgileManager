using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Builders;
using System;

namespace MeControla.AgileManager.Core.Builders
{
    internal class DeployBuilder : BaseBuilder<DeployBuilder, Deploy>, IBuilder<Deploy>
    {
        protected override void Initialize()
            => obj = new()
            {
                Uuid = Guid.NewGuid()
            };

        public DeployBuilder SetServices(string value)
            => Set(obj => obj.Services = value);

        public DeployBuilder SetDeployedIn(DateTime? value)
            => Set(obj => obj.DeployedIn = value);
    }
}