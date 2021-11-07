using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using System.Xaml;
using CV19.Annotations;

namespace CV19.ViewModels.Base
{
    internal abstract class ViewModel : MarkupExtension, INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field,value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }



        public override object ProvideValue(IServiceProvider sp)
        {
            var valueTargetServce = sp.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            var rootOBjectProvider = sp.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;
            
            OnInitialized(
                valueTargetServce?.TargetObject,
                valueTargetServce?.TargetProperty,
                rootOBjectProvider?.RootObject);

            return this;
        }

        private WeakReference _targetRef;
        private WeakReference _rootRef;

        public object TargetIObject => _targetRef.Target;
        public object RootObject => _rootRef.Target; 

        protected virtual void OnInitialized(object target, object property, object root)
        {
            _targetRef = new WeakReference(target);
            _rootRef = new WeakReference(root);
        }
        public void Dispose()
        {
            Dispose(true);
        }

        private bool _disposed;

        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposing || _disposed) return;
            _disposed = true;
            // освобождение управляемых ресурсов
        }
    }
}