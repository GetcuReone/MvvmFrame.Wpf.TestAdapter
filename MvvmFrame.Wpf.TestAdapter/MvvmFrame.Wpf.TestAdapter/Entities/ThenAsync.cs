﻿using MvvmFrame.Wpf.TestAdapter.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Block 'Then'
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class ThenAsync<TInput, TOutput> : AsyncBlockBase<TInput, TOutput>
    {
        /// <summary>
        /// Block name
        /// </summary>
        public override string NameBlock => "Then";
        internal ThenAsync() { }

        #region And Then

        /// <summary>
        /// And this
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual Then<object, object> And(string discription, Action thisBlock)
        {
            return new Then<object, object>
            {
                CodeBlock = _ =>
                {
                    thisBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And this
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual Then<TOutput, object> And(string discription, Action<TOutput> thisBlock)
        {
            return new Then<TOutput, object>
            {
                CodeBlock = output =>
                {
                    thisBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And this
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual Then<object, TOutput2> And<TOutput2>(string discription, Func<TOutput2> thisBlock)
        {
            return new Then<object, TOutput2>
            {
                CodeBlock = _ => thisBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// And this
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual Then<TOutput, TOutput2> And<TOutput2>(string discription, Func<TOutput, TOutput2> thisBlock)
        {
            return new Then<TOutput, TOutput2>
            {
                CodeBlock = thisBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion

        #region And ThenAsync

        /// <summary>
        /// this
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual ThenAsync<object, object> AndAsync(string discription, Func<ValueTask> thisBlock)
        {
            return new ThenAsync<object, object>
            {
                CodeBlock = async _ =>
                {
                    await thisBlock();
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// this
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual ThenAsync<TOutput, object> AndAsync(string discription, Func<TOutput, ValueTask> thisBlock)
        {
            return new ThenAsync<TOutput, object>
            {
                CodeBlock = async output =>
                {
                    await thisBlock(output);
                    return null;
                },
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// this
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual ThenAsync<object, TOutput2> AndAsync<TOutput2>(string discription, Func<ValueTask<TOutput2>> thisBlock)
        {
            return new ThenAsync<object, TOutput2>
            {
                CodeBlock = _ => thisBlock(),
                Discription = discription,
                PreviousBlock = this,
            };
        }

        /// <summary>
        /// this
        /// </summary>
        /// <typeparam name="TOutput2"></typeparam>
        /// <param name="discription"></param>
        /// <param name="thisBlock"></param>
        /// <returns></returns>
        public virtual ThenAsync<TOutput, TOutput2> AndAsync<TOutput2>(string discription, Func<TOutput, ValueTask<TOutput2>> thisBlock)
        {
            return new ThenAsync<TOutput, TOutput2>
            {
                CodeBlock = thisBlock,
                Discription = discription,
                PreviousBlock = this,
            };
        }

        #endregion

        /// <summary>
        /// run given-block-then
        /// </summary>
        /// <param name="getFrame"></param>
        public virtual void Run<TWindow>(Func<TWindow, Frame> getFrame)
            where TWindow : Window, new()
        {
            Stack<BlockBase> blocksStack = new Stack<BlockBase>();
            BlockBase block = this;

            while (true)
            {
                blocksStack.Push(block);

                if (block.PreviousBlock == null)
                    break;
                else
                    block = block.PreviousBlock;
            }

            TWindow window = new TWindow();

            window.Loaded += async (sender, e) => await GivenWhenThenHelper.RunCodeBlockAndCloseWindow(blocksStack, window, getFrame);

            window.ShowDialog();
        }
    }
}
