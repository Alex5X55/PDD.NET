import React, { PropsWithChildren } from "react";
import { NavLink, NavLinkProps } from "react-router-dom";
import styles from "./custom-nav-link.module.css";

interface CustomNavLinkProps extends NavLinkProps {
  className?: string;
}

const CustomNavLink: React.FC<PropsWithChildren<CustomNavLinkProps>> = ({
  className,
  children,
  ...props
}) => {
  return (
    <NavLink {...props} className={styles.nav_link_main}>
      {({ isActive }) => (
        <span className={isActive ? styles.link_active : styles.link_inactive}>
          {children}
        </span>
      )}
    </NavLink>
  );
};

export default CustomNavLink;
