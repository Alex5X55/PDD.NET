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
    <NavLink {...props}>
      {({ isActive }) => (
        <span className={`${className} ${isActive ? styles.custom : ""}`}>
          {children}
        </span>
      )}
    </NavLink>
  );
};

export default CustomNavLink;
