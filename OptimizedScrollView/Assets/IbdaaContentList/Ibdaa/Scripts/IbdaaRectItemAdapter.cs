using System.Collections;
using System.Collections.Generic;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util;
using UnityEngine.UI;
using UnityEngine;
using System;


namespace frame8.ScrollRectItemsAdapter.SimpleTutorialExample
{
	public class IbdaaRectItemAdapter : SRIA<IbdaaParams , IbdaaContentViewsHolder>
	{
		protected override void Start()
		{
			base.Start ();
			OnItemCountChanged (80);
		}

		protected override IbdaaContentViewsHolder CreateViewsHolder (int contentIndex)
		{
			var instance = new IbdaaContentViewsHolder ();
			instance.Init (_Params.itemPrefab, contentIndex);
			return instance;
		}


		protected override void UpdateViewsHolder(IbdaaContentViewsHolder newOrRecycled)
		{
			var model = _Params.Data [newOrRecycled.ItemIndex];
			//newOrRecycled._titleText.text = model._contentTitle;
			newOrRecycled._iconImage.texture = _Params.availableIcons [model._thumbnailIndex];
		}


		public void OnAddItemRequested()
		{
			int index = _Params.Data.Count - 1;
			_Params.Data.Add (CreateNewModel(index));
			InsertItems (index, 1);
		}


		public void OnRemoveItemRequested()
		{
			if (_Params.Data.Count == 0)
				return;

				int index = 0;
			_Params.Data.RemoveAt (index);
			RemoveItems (index, 1);
			
		}


		public void OnItemCountChanged (int newCount)
		{
			_Params.Data.Clear ();
			for (int i = 0; i < newCount; i++)
			{
				_Params.Data.Add (CreateNewModel(i));
			}

			ResetItems (newCount);
		}

		IbdaaModel CreateNewModel (int itemIndex)
		{
			return new IbdaaModel () {
				_contentTitle = "Item",
				_thumbnailIndex = UnityEngine.Random.Range (0, _Params.availableIcons.Length)	
			};
		} 

	}




	public class IbdaaModel
	{
		public string _thumbnailURL;
		public string _contentTitle;
		public int _thumbnailIndex;
		public bool  _isAvailable;

	}

	[Serializable]
	public class IbdaaParams : BaseParamsWithPrefabAndData<IbdaaModel>
	{
		public Texture2D[] availableIcons;

	}
		
	public class IbdaaContentViewsHolder : BaseItemViewsHolder
	{
		public Text _titleText;
		public Image _placeholderAnim;
		public RawImage _iconImage;


		public override void CollectViews()
		{
			base.CollectViews ();
		}

	}

}
