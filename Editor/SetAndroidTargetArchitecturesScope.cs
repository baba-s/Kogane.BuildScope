using System;
using UnityEditor;

namespace Kogane
{
    /// <summary>
    /// PlayerSettings.Android.targetArchitectures の設定と復元を行うスコープ
    /// </summary>
    public sealed class SetAndroidTargetArchitecturesScope : IDisposable
    {
        //================================================================================
        // 変数(readonly)
        //================================================================================
        private readonly bool                m_isAndroid;
        private readonly AndroidArchitecture m_oldTargetArchitectures;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetAndroidTargetArchitecturesScope
        (
            BuildTarget         buildTarget,
            AndroidArchitecture targetArchitectures
        ) : this
        (
            isAndroid: buildTarget == BuildTarget.Android,
            targetArchitectures: targetArchitectures
        )
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetAndroidTargetArchitecturesScope
        (
            BuildTargetGroup    targetGroup,
            AndroidArchitecture targetArchitectures
        ) : this
        (
            isAndroid: targetGroup == BuildTargetGroup.Android,
            targetArchitectures: targetArchitectures
        )
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetAndroidTargetArchitecturesScope
        (
            bool                isAndroid,
            AndroidArchitecture targetArchitectures
        )
        {
            m_isAndroid = isAndroid;

            if ( !m_isAndroid ) return;

            m_oldTargetArchitectures = PlayerSettings.Android.targetArchitectures;

            PlayerSettings.Android.targetArchitectures = targetArchitectures;
        }

        /// <summary>
        /// 破棄される時に呼び出されます
        /// </summary>
        public void Dispose()
        {
            if ( !m_isAndroid ) return;

            PlayerSettings.Android.targetArchitectures = m_oldTargetArchitectures;
        }
    }
}