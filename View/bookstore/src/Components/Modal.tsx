import * as React from 'react';
import './Modal.css'

interface IModalProps {
  children: React.ReactNode
  handleClose(event: any): void;
  handleConfirm(event: any): void;
}

const Modal: React.StatelessComponent<IModalProps> = (props: IModalProps) : React.ReactElement<any> => 
  (
    <div>
      <div className="fundo" />
      <div className="modal">
        <div className="header">
          <button className="bt-close-modal" onClick={props.handleClose}>
            X
          </button>
        </div>

        <div className="body">
          {props.children}
        </div>

        <div className="footer">
          <button className="bt-confirmar" onClick={props.handleConfirm}>
            CONFIRMAR
          </button>
          <br />
        </div>
      </div>
    </div>
  );

export default Modal;