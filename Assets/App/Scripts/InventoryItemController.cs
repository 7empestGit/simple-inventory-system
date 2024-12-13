using System;
using App.Models;
using UnityEngine;
using DG.Tweening;

namespace App
{
    public class InventoryItemController : MonoBehaviour, IMovable
    {
        public const float MoveDuration = 1.0f;
        
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Collider coll;
        [SerializeField] private InventoryItemModel model;
        public InventoryItemModel Model => model;

        public bool IsInteractable { get; set; }
        public Action ClickHandler { get; set; }

        private Camera mainCamera;
        private Vector3 offset;

        private bool isDragging = false;

        #region Unity Methods

        void Awake()
        {
            mainCamera = Camera.main; // Cache main camera, because Camera.main can be slow
        }

        void OnMouseDown()
        {
            if (rb == null)
                return;

            isDragging = true;

            Vector3 objectPosition = transform.position;
            Vector3 mousePosition = mainCamera.WorldToScreenPoint(objectPosition);
            offset = objectPosition - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, mousePosition.z));

            rb.isKinematic = true;
        }

        void OnMouseDrag()
        {
            if (!isDragging)
                return;

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.WorldToScreenPoint(transform.position).z);
    
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePos);

            rb.position = new Vector3(mouseWorldPosition.x + offset.x, mouseWorldPosition.y + offset.y, transform.position.z);
        }

        void OnMouseUp()
        {
            if (!isDragging)
                return;

            isDragging = false;
            rb.isKinematic = false;
        }

        #endregion

        public void Move(Vector3 position, Quaternion rotation)
        {
            transform.DOMove(position, MoveDuration);
            transform.DORotateQuaternion(rotation, MoveDuration);
        }

        public void ToggleInteractions(bool toEnable)
        {
            IsInteractable = toEnable;
            isDragging = false;
            rb.isKinematic = !toEnable;
            coll.enabled = toEnable;
        }
    }
}