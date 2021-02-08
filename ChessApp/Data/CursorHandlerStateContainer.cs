using Microsoft.AspNetCore.Components;
using Chess.Pieces;
using System;

namespace ChessApp.Data
{
    public class CursorHandlerStateContainer : StateContainer
    {
        public bool IsDragged
        {
            get => Target != default;
        }

        protected IPiece target;
        public IPiece Target
        {
            get => target;
            set
            {
                target = value;
                OnPropertyChanged();
            }
        }

        public void ReleaseElement()
        {
            Target = default;
        }

        public void BindElement(IPiece target)
        {
            Target = target;
        }
    }
}
