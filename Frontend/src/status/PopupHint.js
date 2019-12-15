import React, { Component, useEffect } from 'react';
import './PopupHint.css';

const PopUpHint = ({ handleClose, show, children }) => {
  const showHideClassName = show ? 'modal display-block' : 'modal display-none';

  useEffect(() => {
    setTimeout(() => handleClose(), 5000);
  }, []);

  return (
    <div className={showHideClassName}>
      <section className="modal-main">
        {children}
        <button onClick={handleClose} className="btn btn-secondary btn-lg">
          Close
        </button>
      </section>
    </div>
  );
};

export default PopUpHint;
