﻿using System.Threading;

namespace DotnetSpider.Network.InternetDetector
{
	/// <summary>
	/// 网络状态检测器
	/// </summary>
	public abstract class InternetDetectorBase : IInternetDetector
	{
		/// <summary>
		/// 检测网络状态
		/// </summary>
		/// <returns>如果返回 True, 表示当前可以访问互联网</returns>
		protected abstract bool DoValidate();

		/// <summary>
		/// 超时时间
		/// </summary>
		public int Timeout { get; set; } = 10;

		/// <summary>
		/// 检测网络状态
		/// </summary>
		/// <returns>如果返回 True, 表示当前可以访问互联网</returns>
		public bool Detect()
		{
			var currentWaitTime = 0;
			while (currentWaitTime < Timeout)
			{
				currentWaitTime++;
				try
				{
					if (DoValidate())
					{
						return true;
					}

					if (currentWaitTime > 4)
					{
						return false;
					}

					Thread.Sleep(100);
				}
				catch
				{
					// ignored
				}
			}

			return false;
		}
	}
}