using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Markup;
using System.Xaml;

namespace MVVMvideo04part04.ViewModels.Base
{
    /// <summary>
    /// Базовый класс   ViewModel   Модели представления
    /// </summary>
    internal abstract class ViewModel : MarkupExtension, INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        public override object ProvideValue(IServiceProvider sp)
        {
            //целевой объект к которому выполняется обращение
            var value_target_service = sp.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;

            //сервисы которые позволяют получить доступ к этим объектам
            var root_object_service = sp.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;
            //var 
            OnInitialized(
                value_target_service?.TargetObject,
                value_target_service?.TargetProperty,
                root_object_service?.RootObject);

            return this;
        }

        private WeakReference _TargerRef;
        private WeakReference _RootRef;

        public object TargetObject => _TargerRef.Target;
        public object RootObject => _RootRef.Target;

        protected virtual void OnInitialized(object Target,object Property, object Root)
        {
            _TargerRef = new WeakReference(Target);
            _RootRef = new WeakReference(Root);
        }


        public void Dispose()
        {
            Dispose(true);
        }

        private bool _Disposed;
        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposing || _Disposed) return;
            _Disposed = true;
            // Освобождение управляемых ресурсов
        }

    }
}
