using System;
using UnityEditor;

namespace Kogane
{
    /// <summary>
    /// EditorUserBuildSettings.buildAppBundle の設定と復元を行うスコープ
    /// </summary>
    public sealed class SetBuildAppBundleScope : IDisposable
    {
        //================================================================================
        // 変数(readonly)
        //================================================================================
        private readonly bool m_isAndroid;
        private readonly bool m_oldBuildAppBundle;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetBuildAppBundleScope
        (
            BuildTarget target,
            bool        buildAppBundle
        ) : this
        (
            isAndroid: target == BuildTarget.Android,
            buildAppBundle: buildAppBundle
        )
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetBuildAppBundleScope
        (
            BuildTargetGroup targetGroup,
            bool             buildAppBundle
        ) : this
        (
            isAndroid: targetGroup == BuildTargetGroup.Android,
            buildAppBundle: buildAppBundle
        )
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetBuildAppBundleScope
        (
            bool isAndroid,
            bool buildAppBundle
        )
        {
            m_isAndroid = isAndroid;

            if ( !m_isAndroid ) return;

            m_oldBuildAppBundle = EditorUserBuildSettings.buildAppBundle;

            EditorUserBuildSettings.buildAppBundle = buildAppBundle;
        }

        /// <summary>
        /// 破棄される時に呼び出されます
        /// </summary>
        public void Dispose()
        {
            if ( !m_isAndroid ) return;

            EditorUserBuildSettings.buildAppBundle = m_oldBuildAppBundle;
        }
    }
}