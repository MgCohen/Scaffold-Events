using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Scaffold.Core.Events.Signals;

namespace Scaffold.Core.Events
{
    public class Signal
    {
        public Signal(ISignalBroker eventBroker)
        {
            _broker = eventBroker;
        }

        private static ISignalBroker broker
        {
            get
            {
                if (_broker == null)
                {
                    Debug.Log("Events not initialized, pass a valid EventBroker on the Events constructor");
                }
                return _broker;
            }
        }

        private static ISignalBroker _broker;

        public static void Register<T>(Type type, Action<T> callback) where T : ISignal
        {
            broker?.Register(type, callback);
        }

        public static void Register(Type type, Action callback)
        {
            broker?.Register(type, callback);
        }

        public static void Register<T>(Action callback) where T : ISignal, new()
        {
            Register(typeof(T), callback);
        }
        public static void Register<T>(Action<T> callback) where T : ISignal, new()
        {
            Register<T>(typeof(T), callback);
        }

        public static void Unregister<T>(Type type, Action<T> callback) where T : ISignal
        {
            broker?.Unregister(type, callback);
        }
        public static void Unregister(Type type, Action callback)
        {
            broker?.Unregister(type, callback);
        }

        public static void Unregister<T>(Action callback) where T : ISignal, new()
        {
            Unregister(typeof(T), callback);
        }

        public static void Unregister<T>(Action<T> callback) where T : ISignal, new()
        {
            Unregister<T>(typeof(T), callback);
        }

        public static void Raise<T>(T signal) where T: ISignal
        {
            broker?.Raise(signal);
        }

        public static void Raise<T>() where T : ISignal, new()
        {
            Raise(new T());
        }
    }
}