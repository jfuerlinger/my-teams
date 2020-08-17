﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace MyTeams.Frontend.ServicePoC
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for Channels.
    /// </summary>
    public static partial class ChannelsExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<Channel> Get(this IChannels operations)
            {
                return Task.Factory.StartNew(s => ((IChannels)s).GetAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<Channel>> GetAsync(this IChannels operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='channelId'>
            /// </param>
            /// <param name='newerThan'>
            /// </param>
            public static IList<MessageDto> GetMessagesByChannelId(this IChannels operations, int channelId, DateTime newerThan)
            {
                return Task.Factory.StartNew(s => ((IChannels)s).GetMessagesByChannelIdAsync(channelId, newerThan), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='channelId'>
            /// </param>
            /// <param name='newerThan'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<MessageDto>> GetMessagesByChannelIdAsync(this IChannels operations, int channelId, DateTime newerThan, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetMessagesByChannelIdWithHttpMessagesAsync(channelId, newerThan, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}