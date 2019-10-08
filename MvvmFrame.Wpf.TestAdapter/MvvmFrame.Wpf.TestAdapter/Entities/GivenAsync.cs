using System;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Given code block
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class GivenAsync<TInput, TOutput> : AsyncBlockBase<TInput, TOutput>
    {
        internal GivenAsync() { }

        /// <summary>
        /// Block name
        /// </summary>
        public override string NameBlock => "GivenAsync";

        #region And Given

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual Given<object, object> And(string discription, Action givenBlock)
        {
            return new Given<object, object>
            {
                CodeBlock = _ =>
                {
                    givenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual Given<TOutput, object> And(string discription, Action<TOutput> givenBlock)
        {
            return new Given<TOutput, object>
            {
                CodeBlock = output =>
                {
                    givenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual Given<object, TOutput2> And<TOutput2>(string discription, Func<TOutput2> givenBlock)
        {
            return new Given<object, TOutput2>
            {
                CodeBlock = _ => givenBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual Given<TOutput, TOutput2> And<TOutput2>(string discription, Func<TOutput, TOutput2> givenBlock)
        {
            return new Given<TOutput, TOutput2>
            {
                CodeBlock = givenBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion

        #region And GivenAsync

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual GivenAsync<object, object> AndAsync(string discription, Func<ValueTask> givenBlock)
        {
            return new GivenAsync<object, object>
            {
                CodeBlock = async _ =>
                {
                    await givenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual GivenAsync<TOutput, object> AndAsync(string discription, Func<TOutput, ValueTask> givenBlock)
        {
            return new GivenAsync<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await givenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual GivenAsync<object, TOutput2> AndAsync<TOutput2>(string discription, Func<ValueTask<TOutput2>> givenBlock)
        {
            return new GivenAsync<object, TOutput2>
            {
                CodeBlock = _ => givenBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And given
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        public virtual GivenAsync<TOutput, TOutput2> AndAsync<TOutput2>(string discription, Func<TOutput, ValueTask<TOutput2>> givenBlock)
        {
            return new GivenAsync<TOutput, TOutput2>
            {
                CodeBlock = givenBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion

        #region And When

        /// <summary>
        /// When
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual When<object, object> When(string discription, Action whenBlock)
        {
            return new When<object, object>
            {
                CodeBlock = _ =>
                {
                    whenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual When<TOutput, object> When(string discription, Action<TOutput> whenBlock)
        {
            return new When<TOutput, object>
            {
                CodeBlock = output =>
                {
                    whenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual When<object, TOutput2> When<TOutput2>(string discription, Func<TOutput2> whenBlock)
        {
            return new When<object, TOutput2>
            {
                CodeBlock = _ => whenBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual When<TOutput, TOutput2> When<TOutput2>(string discription, Func<TOutput, TOutput2> whenBlock)
        {
            return new When<TOutput, TOutput2>
            {
                CodeBlock = whenBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion

        #region And WhenAsync

        /// <summary>
        /// When
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual WhenAsync<object, object> WhenAsync(string discription, Func<ValueTask> whenBlock)
        {
            return new WhenAsync<object, object>
            {
                CodeBlock = async _ =>
                {
                    await whenBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual WhenAsync<TOutput, object> WhenAsync(string discription, Func<TOutput, ValueTask> whenBlock)
        {
            return new WhenAsync<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await whenBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual WhenAsync<object, TOutput2> WhenAsync<TOutput2>(string discription, Func<ValueTask<TOutput2>> whenBlock)
        {
            return new WhenAsync<object, TOutput2>
            {
                CodeBlock = _ => whenBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// When
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual WhenAsync<TOutput, TOutput2> WhenAsync<TOutput2>(string discription, Func<TOutput, ValueTask<TOutput2>> whenBlock)
        {
            return new WhenAsync<TOutput, TOutput2>
            {
                CodeBlock = whenBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion
    }
}
