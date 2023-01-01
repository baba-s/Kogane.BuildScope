using System;
using UnityEditor;

namespace Kogane
{
    /// <summary>
    /// PlayerSettings.SetApplicationIdentifier の設定と復元を行うスコープ
    /// </summary>
    public sealed class SetApplicationIdentifierScope : IDisposable
    {
        //================================================================================
        // 変数(readonly)
        //================================================================================
        private readonly BuildTargetGroup m_targetGroup;
        private readonly string           m_oldIdentifier;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetApplicationIdentifierScope
        (
            BuildTargetGroup targetGroup,
            string           identifier
        )
        {
            m_targetGroup   = targetGroup;
            m_oldIdentifier = PlayerSettings.GetApplicationIdentifier( m_targetGroup );

            PlayerSettings.SetApplicationIdentifier( m_targetGroup, identifier );
        }

        /// <summary>
        /// 破棄される時に呼び出されます
        /// </summary>
        public void Dispose()
        {
            PlayerSettings.SetApplicationIdentifier( m_targetGroup, m_oldIdentifier );
        }
    }
}