import React from "react";
import styles from "./preloader.module.css";

const Preloader = () => (
  <div className={styles.spinner}>
    <div className={styles.doubleBounce1}></div>
    <div className={styles.doubleBounce2}></div>
  </div>
);

export default Preloader;
