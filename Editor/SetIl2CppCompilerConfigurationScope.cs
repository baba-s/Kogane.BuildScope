using System;
using UnityEditor;

namespace Kogane
{
    /// <summary>
    /// PlayerSettings.SetIl2CppCompilerConfiguration の設定と復元を行うスコープ
    /// </summary>
    public sealed class SetIl2CppCompilerConfigurationScope : IDisposable
    {
        //================================================================================
        // 変数(readonly)
        //================================================================================
        private readonly BuildTargetGroup            m_targetGroup;
        private readonly Il2CppCompilerConfiguration m_oldConfiguration;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetIl2CppCompilerConfigurationScope
        (
            BuildTargetGroup            targetGroup,
            Il2CppCompilerConfiguration configuration
        )
        {
            m_targetGroup      = targetGroup;
            m_oldConfiguration = PlayerSettings.GetIl2CppCompilerConfiguration( m_targetGroup );

            PlayerSettings.SetIl2CppCompilerConfiguration( m_targetGroup, configuration );
        }

        /// <summary>
        /// 破棄される時に呼び出されます
        /// </summary>
        public void Dispose()
        {
            PlayerSettings.SetIl2CppCompilerConfiguration( m_targetGroup, m_oldConfiguration );
        }
    }
}